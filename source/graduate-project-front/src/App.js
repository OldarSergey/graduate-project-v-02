import './App.css';
import SidePanel from './components/panelNavigation/SidePanel';
import {Routes, Route} from 'react-router-dom'
import IncomingDocWork from './pages/IncomingDocWork';
import OutgoingDocWork from './pages/OutgoingDocWork';
function App() {
  return (
    <div className="flex">
      <SidePanel>
      </SidePanel>
  


      <Routes>
        <Route path='/IncomingDocWork' element={<IncomingDocWork/>}/>
        <Route path='/OutgoingDocWork' element={<OutgoingDocWork/>} />
      </Routes>
    </div>
  );
}

export default App;
