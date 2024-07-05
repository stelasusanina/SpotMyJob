import React from "react";
import "./Home.css";
import CategoriesBlock from "../../components/categoriesBlock/CategoriesBlock";

export default function Home() {
  return (
    <div className="container w-full">
      <div className="search-section"></div>
      <CategoriesBlock />
    </div>
  );
}
