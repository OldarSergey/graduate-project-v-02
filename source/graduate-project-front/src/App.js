import './App.css';
import Sidebar from './components/panelNavigation/Sidebar';
import {Routes, Route} from 'react-router-dom'
import IncomingDocWork from './pages/IncomingDocWork';
import OutgoingDocWork from './pages/OutgoingDocWork';
import IncomingDocSpent from './pages/IncomingDocSpent';
import {BsFillImageFill, BsPerson} from 'react-icons/bs'
import {AiOutlineBarChart, AiOutlineFileText, AiOutlineLogout, AiOutlineMail, AiOutlineSetting} from "react-icons/ai";

function App() {
  const menuItems = [
    { text: 'Входящие', path: './IncomingDocWork'},
      { text: 'Исходящие', icon: <AiOutlineFileText />, path: './OutgoingDocWork'},
      { text: 'На контроле', spacing: true, icon: <BsFillImageFill /> },
      { text: 'Архивы', icon: <AiOutlineBarChart /> },
      { text: 'Избранное', icon: <AiOutlineMail /> },
      { text: 'Поиск', icon: <AiOutlineMail /> },
      { text: 'Profile', spacing: true, icon: <BsPerson /> },
      { text: 'Setting', icon: <AiOutlineSetting /> },
      { text: 'Logout', icon: <AiOutlineLogout /> },
  ];
  return (
    <div className="flex">
      

      <Sidebar menuItems={menuItems}></Sidebar>  
  


      <Routes>
        <Route path='/IncomingDocWork' element={<IncomingDocWork/>}/>
        <Route path='/IncomingDocSpent' element={<IncomingDocSpent/>}/>
        <Route path='/OutgoingDocWork' element={<OutgoingDocWork/>} />
      </Routes>
    </div>
  );
}

export default App;
