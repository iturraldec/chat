import '../src/Chat.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { useEffect, useState } from 'react';
import ChatView from './ChatView';
import * as signalR from '@microsoft/signalr';

//
let connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5133/chatHub/").build();

//
export default function Chat({ session, idRoom }) {
  const [mensajes, setMensajes] = useState([]);
  const [message, setMessage] = useState('');
  
  //
  useEffect(() => {
    // sonido-saludo 
    const audio = new Audio("/src/assets/EnterUser.mp3");

    audio.play();

    // inicio signalr
    connection.start()
      .then(() => {
        // me agrego al grupo
        connection.invoke("AddGroup", idRoom.toString());
      })
      .catch((error) => {
        console.error("Error en la conexión: ", error);
      });


    // recibo mensajes desde el servidor
    connection.on("ReceiveMessage", function (idMessage, idUser, userName, message, fecha) {
      var _message = {
        id: idMessage,
        idUser: idUser,
        userName: userName,
        message:message,
        dateCreated:fecha,
        typeMessage: (idUser == session.id) ? 1 : 2
      }

      console.log(_message);
      setMensajes(prevMensajes => [...prevMensajes, _message]);
    });

    // cargo los mensajes
    fetch('http://localhost:5133/api/message', {
      method: 'POST',
      body: JSON.stringify({
        AccessToken: session.accessToken,
        IdRoom: idRoom
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      },
    })
    .then((response) => response.json())
    .then((json) => {
      setMensajes(json.data);
    });

    // limpio...
    return () => {
      audio.pause();
      audio.currentTime = 0;
    };
  }, []);

  //
  function sendMessage() {
    connection.invoke("SendMessage", idRoom, session.id, session.name, message, session.accessToken)
              .catch(function (err) {
                return console.error(err.toString());
              })                
  }

  //
  return (<>
    <Container>
      <Row>
        <Col className='mt-3'>
          <b>Mensajes de usuarios de la sala: { idRoom }</b>
          
          {mensajes && <ChatView mensajes={mensajes}/>}

          <div style={{ height:"5vh" }}>
              <input type="text"
                value={message}
                className='mx-2' 
                onChange={(e) => setMessage(e.target.value)}
                placeholder="Escribe un mensaje..." 
                style={{ width:'90%' }}
              />

              <input type="button" value="Enviar" className="btn btn-success" onClick={() => sendMessage()} />
          </div>

        </Col>
      </Row>
    </Container>
    </>
  )
}