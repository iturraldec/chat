import 'bootstrap/dist/css/bootstrap.min.css';
import '../src/Chat.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { useEffect, useState } from 'react';

export default function Chat({ session, idRoom }) {
  const [mensajes, setMensajes] = useState(null);

  // cargo los mensajes
  useEffect(() => {
    //console.log(session);
    /*
    fetch('http://localhost:5133/api/message', {
      method: 'POST',
      body: JSON.stringify({
        IdRoom: session.IdRoom,
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      },
    })
    .then((response) => response.json())
    .then((json) => {
      if (json.result == 0)
        setMessageError('Error en datos ingresados.');
      else setSession(json.data)
    });
  }*/
  }, []);

  return (
    <Container>
      <Row>
        <Col className='mt-3'>
          <b>Mensajes de usuarios de la sala: { idRoom }</b>

          <div className='chat-container m-2'>
              
          </div>

          <div style={{ height:"5vh" }}>
              <input className='mx-2' placeholder="Escribe un mensaje..." type="text" style={{ width:'90%' }} />
              <input type="button" value="Enviar" className="btn btn-success" />
          </div>

        </Col>
      </Row>
    </Container>
  )
}