import { useState } from "react";
import Room from './Room';
import Chat from './Chat';

export default function Home({ session }) {
  const [idRoom, setIdRoom] = useState(null);

  return (idRoom != null) ? <Chat session={ session } idRoom={ idRoom } /> : <Room session={ session } setIdRoom={ setIdRoom }/>;
}