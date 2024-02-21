import React, { Children, useState } from 'react';
import "./SidePanel.css"
import {AiFillEnvironment} from "react-icons/ai";



const Logo = ({ open }) => (
    <div className='inline-flex'>
      <AiFillEnvironment className={`bg-amber-300 text-4xl rounded cursor-pointer block float-left mr-2 duration-500 ${open && "rotate-[360deg]"}`} />
      <h1 className={`text-white origin-left font-medium text-2xl ${!open && "scale-0"}`}>
        atomuch
      </h1>
    </div>
  );
  export default Logo;