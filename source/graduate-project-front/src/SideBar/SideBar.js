import React, { useState } from 'react';
import 'bootstrap-icons/font/bootstrap-icons.css'; 
import "./SideBar.css"
import {
  CDBSidebar,
  CDBSidebarContent,
  CDBSidebarMenu,
  CDBSidebarMenuItem,
  CDBSidebarFooter,
} from 'cdbreact';
import { Link } from 'react-router-dom';

const Sidebar = () => {
  const [isCollapsed, setIsCollapsed] = useState(false);

  const toggleSidebar = () => {
    setIsCollapsed(!isCollapsed);
  };

  return (
    <div className="sidebar-container">
      <div className={`sidebar-toggle ${isCollapsed ? 'collapsed' : ''}`} onClick={toggleSidebar}>
        <i className={`bi ${isCollapsed ? 'bi-list' : 'bi-list'} toggle-icon white-icon`} />
      </div>
      <CDBSidebar 
        textColor="white" 
        backgroundColor="#0464b4" 
        maxWidth='180px' 
        className={`custom-sidebar ${isCollapsed ? 'collapsed' : ''}`} 
        style={{ display: isCollapsed ? 'none' : 'block' }}
      >

        <CDBSidebarContent className='mt-4'>
          <CDBSidebarMenu>
            <Link to={"./ManageDataEmployees"}><CDBSidebarMenuItem icon="bi bi-person">Сотрудники</CDBSidebarMenuItem></Link>
            <Link to={"./IncomingDocWork"}><CDBSidebarMenuItem icon="bi bi-envelope-arrow-down">Входящие</CDBSidebarMenuItem></Link>
            <Link to={"./OutgoingDocWork"}> <CDBSidebarMenuItem icon="bi bi-envelope-arrow-up">Исходящие</CDBSidebarMenuItem></Link>
            <Link to={"./OutputArchive"}><CDBSidebarMenuItem icon="bi bi-archive">Архивы</CDBSidebarMenuItem></Link>
            <Link to={"./MainPage"}><CDBSidebarMenuItem icon="bi bi-bookmarks">База знаний</CDBSidebarMenuItem></Link>
          </CDBSidebarMenu>
        </CDBSidebarContent>
        <CDBSidebarFooter style={{ textAlign: 'center' }}>
          <div className="sidebar-btn-wrapper" style={{ padding: '20px 5px' }}></div>
        </CDBSidebarFooter>
      </CDBSidebar>
    </div>
  );
};

export default Sidebar;

