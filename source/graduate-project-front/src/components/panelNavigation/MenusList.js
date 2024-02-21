import React, { useEffect, useState } from 'react';
import "./SidePanel.css"
import { Link, useLocation } from 'react-router-dom';
import { RiDashboardFill } from "react-icons/ri";

const MenusList = ({ open, Menus, setSubmenuOpen, submenuOpen }) => {
  const location = useLocation();
  const [activeIcon, setActiveIcon] = useState(null);

  useEffect(() => {
    // Очищаем состояние меню при изменении местоположения
    setSubmenuOpen(false);
  }, [location, setSubmenuOpen]);

  const handleIconClick = (index) => {
    setActiveIcon(index === activeIcon ? null : index);
  };

  return (
    <ul className='pt-2'>
      {Menus.map((menu, index) => (
        <li key={index} className={`text-gray-300 text-sm flex item-center gap-x-4 cursor-pointer p-2 hover:bg-light-white rounded-md ${menu.spacing ? "mt-9" : "mt-2"}`}>
          <Link to={menu.path} className='flex items-center gap-x-4' style={{ width: '110%', display: 'block' }} onClick={() => handleIconClick(index)}>
            <span className={`text-2xl block float-left ${index === activeIcon ? 'text-blue-500' : ''}`}>
              {menu.icon ? menu.icon : <RiDashboardFill />}
            </span>
            <span className={`text-base font-medium duration-200 ${!open && "hidden"}`}>{menu.title}</span>
          </Link>
          {menu.submenu && submenuOpen && open && (
            <ul>
              {menu.submenuItems.map((submenuItem, index) => (
                <li key={index} className='text-gray-300 text-sm flex items-center gap-x-4 cursor-pointer p-2 px-5 hover:bg-light-white rounded-md'>
                  {submenuItem.title}
                </li>
              ))}
            </ul>
          )}
        </li>
      ))}
    </ul>
  );
};

export default MenusList;
