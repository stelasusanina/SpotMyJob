import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function SearchBar({ onSearch }) {
  const [input, setInput] = useState("");
  const navigate = useNavigate();

  const handleInputChange = (e) => {
    setInput(e.target.value);
  };

  const handleSearch = async () => {
    navigate(`/jobs/search?jobTitle=${input}`); 
  };

  return (
    <div>
      <input
        type="text"
        placeholder="Search job title"
        onChange={handleInputChange}
        value={input}
      />
      <button onClick={handleSearch}>Submit</button>
    </div>
  );
}
