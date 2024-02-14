import './App.css';
import IncomingDocWork from './components/IncomingDocWork';
import SidePanel from './components/SidePanel';

function App() {
  return (
    <div className="App">
      <div className="container-fluid">
        <div className="row">
          <div className="col-md-3">
            <SidePanel />
          </div>
          <div className="col-md-9">
            <IncomingDocWork />
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
