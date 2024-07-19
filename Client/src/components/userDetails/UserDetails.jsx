import React, { useEffect, useState } from "react";
import axiosClient from "../../shared/axiosClient";
import { useAuth } from "../../contexts/AuthContext";
import "./UserDetails.css";

export default function UserDetails() {
  const [details, setDetails] = useState({});
  const [myApplications, setMyApplications] = useState([]);
  const { identify } = useAuth();

  useEffect(() => {
    const fetchUserDetails = async () => {
      const userId = await identify();
      try {
        const response = await axiosClient.get(
          `${process.env.REACT_APP_API_BASE_URL}/auth/myProfile/details`,
          {
            params: { userId }
          }
        );
        setDetails(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    const fetchApplications = async () => {
      const userId = await identify();
      try {
        const response = await axiosClient.get(
          `${process.env.REACT_APP_API_BASE_URL}/auth/myProfile/jobApplications`,
          {
            params: { userId }
          }
        );
        setMyApplications(response.data);
      } catch (error) {
        console.log(error);
      }
    }

    fetchUserDetails();
    fetchApplications();
  }, [identify]);

  const removePhoto = () => {
    axiosClient.post(`${process.env.REACT_APP_API_BASE_URL}/auth/myProfile/removeProfilePhoto`, {
      userId: details.id
    })
    .then(() => {
      window.location.reload();
    })
    .catch(error => console.log(error));
  };

  const uploadPhoto = () => {
    const profilePhotoUrl = prompt("Please enter the URL of your profile photo:");
    console.log(profilePhotoUrl);
    if (profilePhotoUrl) {
      axiosClient.post(`${process.env.REACT_APP_API_BASE_URL}/auth/myProfile/uploadProfilePhoto`, {
        profilePhotoUrl
      })
      .then(() => {
        window.location.reload();
      })
      .catch(error => console.log(error));
    }
  };

  return (
    <div className="user-details">
      <div className="user-details-image-container">
        {details.profilePictureUrl ? (
          <img
            src={details.profilePictureUrl}
            alt="profile picture"
            className="profile-picture"
          />
        ) : (
          <img
            src="https://www.iprcenter.gov/image-repository/blank-profile-picture.png/@@images/image.png"
            alt="profile picture"
            className="profile-picture"
          />
        )}
        <div className="user-details-buttons-container">
          <button className="remove-photo" onClick={removePhoto}>
            Remove Photo
          </button>
          <button className="upload-photo" onClick={uploadPhoto}>
            Upload Photo
          </button>
        </div>
      </div>
      {details && (
        <div className="user-details-info">
          <p>{`${details.firstName} ${details.lastName}`}</p>
          <p>{details.phoneNumber}</p>
          <p>{details.email}</p>
          <h3>My applications</h3>
          <div className="my-applications">
            {myApplications &&
              myApplications.map((application) => (
                <div className="application" key={application.id}>
                  <p>{application.jobOfferTitle}</p>
                  <span>See more</span>
                  <div className="see-more">
                    <p>{application.jobCompanyName}</p>
                    <p>{application.uploadedFileName}</p>
                    <p>{application.appliedOn}</p>
                    <p className="status">{application.status}</p>
                  </div>
                </div>
              ))}
          </div>
        </div>
      )}
    </div>
  );
}
