import '../src/Chat.css';

export default function ChatView({ mensajes }) {
  return (
    <div className='chat-container m-2'>
      {mensajes.map(item => (
        <div key={item.id}>
          <div className={item.typeMessage == 1 ? 'chat-message chat-messageRight' : 'chat-message'}>
            <b>{item.userName}</b>

            <div>{item.message}</div>

            <div className='chat-date'>{item.dateCreated}</div>

            <div className='clearfix'></div>
          </div>
        </div>
      ))}
    </div>);
}