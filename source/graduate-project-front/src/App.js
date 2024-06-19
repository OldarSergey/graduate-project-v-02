import React from 'react';
import { Routes, Route } from 'react-router-dom';
import IncomingDocWork from './pages/Documents/IncomingDocWork';
import Sidebar from './SideBar/SideBar';
import './App.css';
import IncomingDocSpent from './pages/Documents/IncomingDocSpent';
import OutgoingDocWork from './pages/Documents/OutgoingDocWork';
import OutputArchive from './pages/Documents/OutputArchive';
import ManageDataEmployees from './pages/Employee/ManageDataEmployees';
import MainPage from './pages/KnowledgeBase/MainPage';

function App() {
  return (
    <div  className="flex-container m-0 p-0">
      <Sidebar />
      <Routes>
      <Route path="/" element={<IncomingDocWork />} />
        <Route path="/IncomingDocWork" element={<IncomingDocWork />} />
        <Route path="/IncomingDocSpent" element={<IncomingDocSpent/>} />
        <Route path="/OutgoingDocWork" element={<OutgoingDocWork />} />
        <Route path="/OutputArchive" element={<OutputArchive />} />
        <Route path='/ManageDataEmployees' element={<ManageDataEmployees/>}/>
        <Route path='/MainPage' element={<MainPage/>}/>
      </Routes>
    </div>
  );
}

export default App;
