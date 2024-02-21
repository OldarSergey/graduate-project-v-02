import React, { Children, useState } from 'react';
import "./SidePanel.css"
import { BsSearch} from 'react-icons/bs'



const Search = ({ open }) => (
    <div className={`flex items-center rounded-md bg-light-white mt-6 ${!open ? "px-2.5" : "px-4"} py-2`}>
      <BsSearch className={`text-white text-lg block float-left cursor-pointer ${open && "mr-2"}`} />
      <input type={'search'} placeholder='Search' className='text-base bg-transparent w-full text-white focus:outline-none'></input>
    </div>
  );
  export default Search;