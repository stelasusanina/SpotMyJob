import React, { useState, useEffect } from "react";
import axiosClient from "../../shared/axiosClient";
import "./OrderBy.css";

export default function OrderBy({ setJobs }) {
  const [order, setOrder] = useState("TitleAscending");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axiosClient.get(
          `${process.env.REACT_APP_API_BASE_URL}/jobs`,
          {
            params: { orderBy: order },
          }
        );
        setJobs(response.data);
      } catch (error) {
        console.error("Error fetching jobs:", error);
      }
    };

    fetchData();
  }, [order, setJobs]);

  const handleOrderChange = async (event) => {
    const selectedOrder = event.target.value;
    setOrder(selectedOrder);
  };

  return (
    <div className="order-by">
      <select value={order} onChange={handleOrderChange}>
        <option value="TitleAscending">Title: A-Z</option>
        <option value="TitleDescending">Title: Z-A</option>
        <option value="NewerDate">Date: Newest</option>
        <option value="OlderDate">Date: Oldest</option>
      </select>
    </div>
  );
};
