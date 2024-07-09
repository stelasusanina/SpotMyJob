import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./pages/home/Home";
import Navbar from "./components/navbar/Navbar";
import Login from "./pages/login/Login";
import Register from "./pages/register/Register";
import { ToastContainer } from "react-toastify";
import Jobs from "./pages/jobs/Jobs";
import SingleJobOffer from "./pages/singleJobOffer/SingleJobOffer";

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route exact path="/" element={<Home />} />
        <Route path="/auth/login" element={<Login />} />
        <Route path="/auth/register" element={<Register />} />
        <Route path="/jobs" element={<Jobs />} />
        <Route path="jobs/:jobId" element={<SingleJobOffer />}/>
      </Routes>
      <ToastContainer />
    </Router>
  );
}

export default App;
