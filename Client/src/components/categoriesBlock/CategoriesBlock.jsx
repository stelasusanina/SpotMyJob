import React, { useEffect, useState } from "react";
import axios from "axios";
import "./CategoriesBlock.css";
import { Link } from "react-router-dom";

export default function CategoriesBlock() {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await axios.get(
          `${process.env.REACT_APP_API_BASE_URL}/home`,
          { withCredentials: true }
        );
        setCategories(response.data);
      } catch (error) {
        console.error("Error fetching categories:", error);
      }
    };

    fetchCategories();
  }, []);

  return (
    <div className="categories-block">
      {categories.map((category) => (
        <Link
          to={`jobs?category=${category.name}`}
          className="category-box"
          key={category.id}>
          <img src={category.imageUrl} alt={category.name} />
          <span>{category.name}</span>
        </Link>
      ))}
    </div>
  );
}
