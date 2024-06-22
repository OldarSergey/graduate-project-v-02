import React, { useState } from 'react';
import { Routes, Route, Navigate, useNavigate } from 'react-router-dom';
import IncomingDocWork from './pages/Documents/IncomingDocWork';
import Sidebar from './SideBar/SideBar';
import './App.css';
import IncomingDocSpent from './pages/Documents/IncomingDocSpent';
import OutgoingDocWork from './pages/Documents/OutgoingDocWork';
import OutputArchive from './pages/Documents/OutputArchive';
import ManageDataEmployees from './pages/Employee/ManageDataEmployees';
import MainPage from './pages/KnowledgeBase/MainPage';
import Login from './pages/Auth/Login';

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const navigate = useNavigate();

  const handleLogin = (username, password) => {
    if (username === 'admin' && password === 'admin') {
      setIsAuthenticated(true);
      navigate('/IncomingDocWork');
    } else {
      alert('Invalid credentials');
    }
  };

  const handleLogout = () => {
    setIsAuthenticated(false);
    navigate('/');
  };

  return (
    <div className="flex-container m-0 p-0">
      {!isAuthenticated ? (
        <Login onLogin={handleLogin} />
      ) : (
        <>
          <Sidebar onLogout={handleLogout} />
          <Routes>
            <Route path="/" element={<Navigate to="/IncomingDocWork" />} />
            <Route path="/IncomingDocWork" element={<IncomingDocWork />} />
            <Route path="/IncomingDocSpent" element={<IncomingDocSpent />} />
            <Route path="/OutgoingDocWork" element={<OutgoingDocWork />} />
            <Route path="/OutputArchive" element={<OutputArchive />} />
            <Route path='/ManageDataEmployees' element={<ManageDataEmployees />} />
            <Route path='/MainPage' element={<MainPage />} />
            <Route path="*" element={<Navigate to="/IncomingDocWork" />} />
          </Routes>
        </>
      )}
    </div>
  );
}

export default App;
