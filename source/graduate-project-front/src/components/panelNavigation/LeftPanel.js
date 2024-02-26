import React, { Children, useState } from 'react';
import "./SidePanel.css"
import {BsFillImageFill, BsReverseLayoutSidebarInsetReverse, BsPerson} from 'react-icons/bs'
import {AiOutlineBarChart, AiOutlineFileText, AiOutlineLogout, AiOutlineMail, AiOutlineSetting} from "react-icons/ai";

import ToggleButton from './ToggleButton';
import Logo from './Logo';
import Search from './Search';
import MenusList from './MenusList';

const LeftPanel = ({ open, setOpen, submenuOpen, setSubmenuOpen }) => {
    const Menus = [
      { title: 'Входящие', path: './IncomingDocWork'},
      { title: 'Исходящие', icon: <AiOutlineFileText />, path: './OutgoingDocWork'},
      { title: 'На контроле', spacing: true, icon: <BsFillImageFill /> },
      { title: 'Архивы', icon: <AiOutlineBarChart /> },
      { title: 'Избранное', icon: <AiOutlineMail /> },
      { title: 'Поиск', icon: <AiOutlineMail /> },
      { title: 'Profile', spacing: true, icon: <BsPerson /> },
      { title: 'Setting', icon: <AiOutlineSetting /> },
      { title: 'Logout', icon: <AiOutlineLogout /> },
    ];
  
    return (
      <div className={`bg-dark-purple h-screen p-5 pt-8 ${open ? "w-72" : "w-20"} duration-300 relative`}>

        <ToggleButton open={open} setOpen={setOpen} />


        <MenusList open={open} Menus={Menus} setSubmenuOpen={setSubmenuOpen} submenuOpen={submenuOpen} />
        
      </div>
    );
  };
  export default LeftPanel;
  