import React, { useEffect, useState } from "react";
import axiosClient from "../../shared/axiosClient";
import { useAuth } from "../../contexts/AuthContext";
import "./UserDetails.css";

export default function UserDetails() {
  const [details, setDetails] = useState({});
  const [myApplications, setMyApplications] = useState([]);
  const [expandedApplications, setExpandedApplications] = useState([]); 
  const { identify } = useAuth();

  useEffect(() => {
    const fetchUserDetails = async () => {
      const userId = await identify();
      try {
        const response = await axiosClient.get(
          `${process.env.REACT_APP_API_BASE_URL}/auth/myProfile/details`,
          {
            params: { userId },
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
            params: { userId },
          }
        );
        setMyApplications(response.data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchUserDetails();
    fetchApplications();
  }, [identify]);

  const removePhoto = () => {
    axiosClient
      .post(
        `${process.env.REACT_APP_API_BASE_URL}/auth/myProfile/removeProfilePhoto`,
        {
          userId: details.id,
        }
      )
      .then(() => {
        window.location.reload();
      })
      .catch((error) => console.log(error));
  };

  const uploadPhoto = () => {
    const profilePhotoUrl = prompt(
      "Please enter the URL of your profile photo:"
    );
    console.log(profilePhotoUrl);
    if (profilePhotoUrl) {
      axiosClient
        .post(
          `${process.env.REACT_APP_API_BASE_URL}/auth/myProfile/uploadProfilePhoto`,
          {
            profilePhotoUrl,
          }
        )
        .then(() => {
          window.location.reload();
        })
        .catch((error) => console.log(error));
    }
  };

  const toggleExpand = (jobOfferId) => {
    setExpandedApplications((prevState) =>
      prevState.includes(jobOfferId)
        ? prevState.filter((id) => id !== jobOfferId)
        : [...prevState, jobOfferId]
    );
  };

  const getStatusClass = (status) => {
    switch(status) {
      case 'Applied':
        return 'Applied';
      case 'In Progress':
        return 'In-progress';
      case 'Completed':
        return 'Completed';
      case 'Rejected':
        return 'Rejected'; 
      default:
        return '';
    }
  }  

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
          <h3>Personal information</h3>
          <p>{`${details.firstName} ${details.lastName}`}</p>
          <p>{details.phoneNumber}</p>
          <p>{details.email}</p>
          <h3>My applications</h3>
          <div className="my-applications">
            {myApplications &&
              myApplications.map((application) => (
                <div className="application" key={application.jobOfferId}>
                  <div className="short-info">
                    <p className="title">{application.jobOfferTitle}</p>
                    <span onClick={() => toggleExpand(application.jobOfferId)}>
                      {expandedApplications.includes(application.jobOfferId) ? (
                        <i class="fa-solid fa-caret-up"></i>
                      ) : (
                        <i class="fa-solid fa-caret-down"></i>
                      )}
                    </span>
                  </div>
                  {expandedApplications.includes(application.jobOfferId) && (
                    <div className="see-more">
                      <p>Company: {application.jobCompanyName}</p>
                      <p>Uploaded file: {application.uploadedFileName}</p>
                      <p>
                        Applied on:{" "}
                        {new Date(application.appliedOn).toLocaleString()}
                      </p>
                      <p>
                        Status:{" "}
                        <span
                          className={`status-${getStatusClass(
                            application.status
                          )}`}>
                          {application.status}
                        </span>
                      </p>{" "}
                    </div>
                  )}
                </div>
              ))}
          </div>
        </div>
      )}
    </div>
  );
}