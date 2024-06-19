import React from 'react';
import "./ContextMenu.css"

const ContextMenu = ({ registrationNumber, posX, posY, onClose, onProperty, onAttachment, onRoute, onPermission, onEvent }) => {
  // Определяем стили для позиционирования контекстного меню
  const menuStyle = {
    position: 'fixed',
    left: posX - 75, // Сдвигаем меню на половину его ширины
    top: posY - 50, // Сдвигаем меню на половину его высоты
    width:'250px'
  };

  return (
    <div>
      <div className="overlay" onClick={onClose} />
      
      <div className="context-menu" style={menuStyle} >

        <span style={{margin:'5px'}}>Документ {registrationNumber} </span>

        <div className="context-menu-item" onClick={onProperty}>
          <span>Свойства</span>
        </div>

        <div className="context-menu-item" onClick={onRoute}>
          <span>Маршрут</span>
        </div>
      
        <div className="context-menu-item cancel" onClick={onClose} style={{color:'red'}}>
          Отмена
        </div>
      </div>
    </div>
  );
};

export default ContextMenu;
