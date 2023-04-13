import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { useState } from 'react';
import { SHA256 } from 'crypto-js';

function App() {
  const [usuario, usuarioMan] = useState('');
  const [password, passwordMan] = useState('');

  function setUsuario(valor) {
    usuarioMan(valor);
  }

  function setPassword(valor) {
    passwordMan(valor);
  }

  function login() {
    fetch('http://localhost:5133/api/access', {
      method: 'POST',
      body: JSON.stringify({
        email: usuario,
        password: SHA256(password).toString()
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      },
    })
    .then((response) => response.json())
    .then((json) => console.log(json));
  }

  return (
    <Container>
      <Row className="mt-5 justify-content-center">
        <Col xs={6}>
          <Form>
            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label>Email address</Form.Label>
              <Form.Control type="email" 
                            placeholder="Enter email" 
                            value={usuario} 
                            onChange={(e) => setUsuario(e.target.value)} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Password</Form.Label>
              <Form.Control type="password" 
                            value={password} 
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder="Password" />
            </Form.Group>
            
            <Button variant="primary" onClick={() => login()}>
              Submit
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  )
}

export default App;