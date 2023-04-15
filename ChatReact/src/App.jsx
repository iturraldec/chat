import Login from './Login';
import Home from './Home';
import { useState } from 'react';

function App() {
  const [session, setSession] = useState(null);

  return session ? <Home session={ session } /> : <Login setSession={ setSession } />;
}

export default App;