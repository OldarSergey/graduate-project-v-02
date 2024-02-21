import React, { Children, useState } from 'react';
import "./SidePanel.css"

import LeftPanel from './LeftPanel';



const SidePanel = ({ children }) => {
  const [open, setOpen] = useState(true);
  const [submenuOpen, setSubmenuOpen] = useState(true);

  return (
    <div className="flex">

      <LeftPanel open={open} setOpen={setOpen} submenuOpen={submenuOpen} setSubmenuOpen={setSubmenuOpen} />
      
   
      <div className='p-3'>
      
      </div>
      
    </div>
  );
};
export default SidePanel;