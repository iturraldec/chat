import 'bootstrap/dist/css/bootstrap.min.css';
import '../src/Chat.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { useEffect, useState } from 'react';
import ChatView from './ChatView';

export default function Chat({ session, idRoom }) {
  const [mensajes, setMensajes] = useState(null);

  // cargo los mensajes
  useEffect(() => {
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
  }, []);

  return (
    <Container>
      <Row>
        <Col className='mt-3'>
          <b>Mensajes de usuarios de la sala: { idRoom }</b>
          
          {mensajes && <ChatView mensajes={mensajes}/>}

          <div style={{ height:"5vh" }}>
              <input className='mx-2' placeholder="Escribe un mensaje..." type="text" style={{ width:'90%' }} />
              <input type="button" value="Enviar" className="btn btn-success" />
          </div>

        </Col>
      </Row>
    </Container>
  )
}