import './App.css';
import Home from './Component/Home';
import AllTest from './Component/AllTest';
import TestPage from './Component/TestPage';
import PrivateRoutes from './utils/PrivateRoutes'
import Login from './Component/Login';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <Router>
        <Routes >
        <Route exact path="/" element={<Login />} />
        <Route exact path="/alltest" element={<AllTest />} />
        <Route exact path="/item/:id" element={<TestPage />} />

        {/* <Route element={<PrivateRoutes />}>
          <Route exact path="/" element={<AllTest />} />
          <Route exact path="/item/:id" element={<TestPage />} />
        </Route> */}

      </Routes>
    </Router>
    </div >
  );
}

export default App;
