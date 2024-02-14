import React, { Children } from 'react';
import "./SidePanel.css"
import incomingDocIcon from "../img/incoming-doc-icon.png";
import outgoingDocIcon from "../img/outgoing-doc-icon.png";
import controlDocIcon from "../img/control-doc-icon.png";
import favouritesDocIcon from "../img/favourites-doc-icon.png";
import archiveDocIcon from "../img/archive-doc-icon.png";
import searchDocIcon from "../img/search-doc-icon.png";


const SidePanel = ({ children }) => {
return (
    <div className="side-panel">
      <img className='panel-icon' src={incomingDocIcon}></img>
      <img className='panel-icon' src={outgoingDocIcon}></img>
      <img className='panel-icon' src={archiveDocIcon}></img>
      <img className='panel-icon' src={controlDocIcon}></img>
      <img className='panel-icon' src={favouritesDocIcon}></img>
      <img className='panel-icon' src={searchDocIcon}></img>
      {children}
    </div>

  );
};

export default SidePanel;