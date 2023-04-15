import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { useEffect, useState } from 'react';

export default function Room({ session, setIdRoom }) {
  const [rooms, setRooms] = useState([]);

  // cargo las salas
  useEffect(() => {
    fetch('http://localhost:5133/api/room', {
        method: 'POST',
        body: JSON.stringify({
          AccessToken: session.accessToken,
        }),
        headers: {
          'Content-type': 'application/json; charset=UTF-8',
        },
      })
      .then((response) => response.json())
      .then((json) => {
          setRooms(json.data);
      })
  }, []);

  //
  return (
    <Container>
      <Row>
        <Col className='mt-3'>
          <h2>Bienvenido: { session.name }</h2>
          <h3>Salas de Chat</h3>

          {rooms && rooms.map(room => (
            <p key={room.id}>{room.name} <Button onClick={ () => setIdRoom(room.id) }>Ir</Button></p>
          ))}
        </Col>
      </Row>
    </Container>
  )
}