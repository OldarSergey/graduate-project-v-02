import React from 'react';
import { Routes, Route } from 'react-router-dom';
import IncomingDocWork from './pages/IncomingDocWork';
import Sidebar from './SideBar/SideBar';
import './App.css';
import IncomingDocSpent from './pages/IncomingDocSpent';
import OutgoingDocWork from './pages/OutgoingDocWork';

function App() {
  return (
    <div  className="flex-container m-0 p-0">
      <Sidebar />
      <Routes>
        <Route path="/IncomingDocWork" element={<IncomingDocWork />} />
        <Route path="/IncomingDocSpent" element={<IncomingDocSpent/>} />
        <Route path="/OutgoingDocWork" element={<OutgoingDocWork />} />
      </Routes>
    </div>
  );
}

export default App;
