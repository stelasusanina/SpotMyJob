import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./SearchBar.css";

export default function SearchBar({className}) {
  const [input, setInput] = useState("");
  const navigate = useNavigate();

  const handleInputChange = (e) => {
    setInput(e.target.value);
  };

  const handleSearch = async () => {
    navigate(`/jobs?jobTitle=${input}`); 
  };

  return (
    <div>
      <input
        className={`search-bar-input-${className}`}
        type="text"
        placeholder="Search by job title"
        onChange={handleInputChange}
        value={input}
        onKeyDown={(e) => e.key === "Enter" && handleSearch()}
      />
      <button
        className={`search-bar-button-${className}`}
        onClick={handleSearch}>
        <i class="fa-solid fa-magnifying-glass"></i> Search
      </button>
    </div>
  );
}
