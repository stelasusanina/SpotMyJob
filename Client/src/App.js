import "./App.css";
import { BrowserRouter as Router, Route, Routes, Navigate } from "react-router-dom";
import Home from "./pages/home/Home";
import Navbar from "./components/navbar/Navbar";
import Login from "./pages/login/Login";
import Register from "./pages/register/Register";
import { ToastContainer } from "react-toastify";
import Jobs from "./pages/jobs/Jobs";
import SingleJobOffer from "./pages/singleJobOffer/SingleJobOffer";
import '@fortawesome/fontawesome-free/css/all.min.css';
import MyProfile from "./pages/myProfile/MyProfile";
import AddNewJobOffer from "./pages/addNewJobOffer/AddNewJobOffer";
import Unauthorized from "./pages/unauthorized/Unauthorized";
import { useAuth } from "./contexts/AuthContext";
import { useEffect, useState } from "react";

export default function App() {
  const { identify, getRole } = useAuth();
  const [user, setUser] = useState(null);
  const [role, setRole] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      const identifiedUser = await identify();
      const userRole = await getRole();
      setUser(identifiedUser);
      setRole(userRole);
    };

    fetchData();
  }, [identify, getRole]);

  return (
    <Router>
      <Navbar />
      <Routes>
        <Route exact path="/" element={<Home />} />
        <Route path="/auth/login" element={<Login />} />
        <Route path="/auth/register" element={<Register />} />
        <Route path="/jobs" element={<Jobs />} />
        <Route path="jobs/:jobId" element={<SingleJobOffer />} />
        <Route path="jobs/search" element={<Jobs />} />
        <Route path="jobs/filter" element={<Jobs />} />
        <Route path="/myProfile" element={<MyProfile />} />
        <Route path="/unauthorized" element={<Unauthorized />} />
        <Route
          path="/admin/addJobOffer"
          element={
            user && role === "Admin" ? (
              <AddNewJobOffer />
            ) : (
              <Navigate to="/unauthorized" />
            )
          }
        />
      </Routes>
      <ToastContainer />
    </Router>
  );
}
