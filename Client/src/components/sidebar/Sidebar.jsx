import React, { useState, useEffect } from "react";
import { useSearchParams } from "react-router-dom";
import axiosClient from "../../shared/axiosClient";

export default function Sidebar() {
  const [categories, setCategories] = useState([]);
  const [selectedCategories, setSelectedCategories] = useState([]);
  const [countries, setCountries] = useState([]);
  const [selectedCountries, setSelectedCountries] = useState([]);
  const [jobTitle, setJobTitle] = useState("");
  const [searchParams, setSearchParams] = useSearchParams();

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await axiosClient.get(
          `${process.env.REACT_APP_API_BASE_URL}/home`
        );
        setCategories(response.data);
      } catch (error) {
        console.error("Error fetching categories:", error);
      }
    };

    const fetchCountries = async () => {
      try {
        const response = await axiosClient.get(
          `${process.env.REACT_APP_API_BASE_URL}/jobs/countries`
        );
        setCountries(response.data);
      } catch (error) {
        console.error("Error fetching countries:", error);
      }
    };

    fetchCategories();
    fetchCountries();
  }, []);

  useEffect(() => {
    const urlCategories = searchParams.get("category");
    if (urlCategories) {
      setSelectedCategories(urlCategories.split(","));
    } else {
      setSelectedCategories([]);
    }

    const urlCountries = searchParams.get("country");
    if (urlCountries) {
      setSelectedCountries(urlCountries.split(","));
    } else {
      setSelectedCountries([]);
    }

    const urlJobTitle = searchParams.get("jobTitle");
    if (urlJobTitle) {
      setJobTitle(urlJobTitle);
    } else {
      setJobTitle("");
    }
  }, [searchParams]);

  const handleCheckboxChange = (type, value) => {
    const params = new URLSearchParams(searchParams);

    if (type === "category") {
      setSelectedCategories((prevSelected) => {
        const newSelected = prevSelected.includes(value)
          ? prevSelected.filter((name) => name !== value)
          : [...prevSelected, value];
        if (newSelected.length > 0) {
          params.set("category", newSelected.join(","));
        } else {
          params.delete("category");
        }
        setSearchParams(params);
        return newSelected;
      });
    } else if (type === "country") {
      setSelectedCountries((prevSelected) => {
        const newSelected = prevSelected.includes(value)
          ? prevSelected.filter((name) => name !== value)
          : [...prevSelected, value];
        if (newSelected.length > 0) {
          params.set("country", newSelected.join(","));
        } else {
          params.delete("country");
        }
        setSearchParams(params);
        return newSelected;
      });
    }
  };

  const handleJobTitleChange = (event) => {
    const value = event.target.value;
    setJobTitle(value);
    const params = new URLSearchParams(searchParams);
    if (value.trim() !== "") {
      params.set("jobTitle", value.trim());
    } else {
      params.delete("jobTitle");
    }
    setSearchParams(params);
  };

  return (
    <div className="sidebar">
      <h2>Filters</h2>
      <div className="sidebar-filter-section">
        <h3>Categories</h3>
        {categories.length > 0 ? (
          categories.map((category) => (
            <div key={category.id}>
              <input
                type="checkbox"
                name={`category-${category.id}`}
                checked={selectedCategories.includes(category.name)}
                onChange={() => handleCheckboxChange("category", category.name)}
              />
              <label>{category.name}</label>
            </div>
          ))
        ) : (
          <p>No categories available</p>
        )}
      </div>
      <div className="sidebar-filter-section">
        <h3>Countries</h3>
        {countries.length > 0 ? (
          countries.map((country, index) => (
            <div key={index}>
              <input
                type="checkbox"
                name={`country-${index}`}
                checked={selectedCountries.includes(country)}
                onChange={() => handleCheckboxChange("country", country)}
              />
              <label>{country}</label>
            </div>
          ))
        ) : (
          <p>No countries available</p>
        )}
      </div>
      <div className="sidebar-filter-section">
        <h3>Job Title</h3>
        <input
          type="text"
          placeholder="Search by job title"
          value={jobTitle}
          onChange={handleJobTitleChange}
        />
      </div>
    </div>
  );
}