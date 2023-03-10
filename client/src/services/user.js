import axios from "axios";

export const getUser = async (token) => {
  let response = {};
  try {
    const r = await axios.get("http://localhost:3000/api/User", {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    response = r.data;
  } catch (error) {
    response.exceptions = error.response.data.exceptions;
  }

  return response;
};
