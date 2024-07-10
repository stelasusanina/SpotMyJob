import React from "react";
import "./Home.css";
import CategoriesBlock from "../../components/categoriesBlock/CategoriesBlock";
import SearchBar from "../../components/searchBar/SearchBar";

export default function Home() {
  return (
    <div className="container w-full">
      <div className="search-section">
        {" "}
        <SearchBar />
      </div>
      <CategoriesBlock />
    </div>
  );
}
