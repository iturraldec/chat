import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { useState } from 'react';
import { SHA256 } from 'crypto-js';

export default function Login({ setSession }) {
  const [usuario, setUsuario] = useState('');
  const [password, setPassword] = useState('');
  const [messageError, setMessageError] = useState('');

  //
  function login() {
    fetch('http://localhost:5133/api/access', {
      method: 'POST',
      body: JSON.stringify({
        email: usuario,
        password: SHA256(password).toString()
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      }
    })
    .then((response) => response.json())
    .then((json) => {
      (json.result == 0) ? setMessageError('Error en datos ingresados.') : setSession(json.data);
    });
  }

  //
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
                              onChange={(e) => {
                                setUsuario(e.target.value);
                                setMessageError('');
                                }
                              } />
              </Form.Group>

              <Form.Group className="mb-3" controlId="formBasicPassword">
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" 
                              value={password} 
                              onChange={(e) => {
                                setPassword(e.target.value);
                                setMessageError('');
                                }
                              }
                              placeholder="Password" />
              </Form.Group>

              {messageError.length > 0 &&
                <div>
                  {messageError}
                </div>
              }

              <Button variant="primary" onClick={() => login()}>
                Submit
              </Button>
            </Form>
          </Col>
        </Row>
    </Container>
  )
}