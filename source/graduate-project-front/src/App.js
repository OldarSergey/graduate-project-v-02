import './App.css';
import Sidebar from './components/panelNavigation/Sidebar';
import {Routes, Route} from 'react-router-dom'
import IncomingDocWork from './pages/IncomingDocWork';
import OutgoingDocWork from './pages/OutgoingDocWork';
import IncomingDocSpent from './pages/IncomingDocSpent';
import {BsPerson} from 'react-icons/bs';
import { GrDocumentDownload, GrDocumentUpload, GrDocumentUser, GrDocumentStore, GrDocumentVerified } from "react-icons/gr";
import { HiOutlineDocumentSearch } from "react-icons/hi";
import OutputArchive from './pages/OutputArchive';

function App() {
  const menuItems = [
    { text: 'Входящие', icon: <GrDocumentDownload />, path: './IncomingDocWork'},
      { text: 'Исходящие', icon: <GrDocumentUpload />, path: './OutgoingDocWork'},
      { text: 'На контроле', spacing: true, icon: <GrDocumentUser /> },
      { text: 'Архивы', icon: <GrDocumentStore />, path: './OutputArchive' },
      { text: 'Избранное', icon: <GrDocumentVerified /> },
      { text: 'Поиск', icon: <HiOutlineDocumentSearch /> },
      { text: 'Профиль', spacing: true, icon: <BsPerson /> },
  ];
  return (
    <div className="flex">
      <Sidebar menuItems={menuItems}></Sidebar>  
      <Routes>
        <Route path='/IncomingDocWork' element={<IncomingDocWork/>}/>
        <Route path='/IncomingDocSpent' element={<IncomingDocSpent/>}/>
        <Route path='/OutgoingDocWork' element={<OutgoingDocWork/>} />
        <Route path='/OutputArchive' element={<OutputArchive/>} />
      </Routes>
    </div>
  );
}

export default App;
