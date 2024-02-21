import {BsArrowLeftShort} from 'react-icons/bs'
const ToggleButton = ({ open, setOpen }) => (
    <BsArrowLeftShort
      className={`bg-white text-dark-purple text-3xl rounded-full absolute -right-3 top-9 border border-dark-purple cursor-pointer ${!open && "rotate-180"}`}
      onClick={() => setOpen(!open)}
    />
  );
  export default ToggleButton;