import axios from "axios";

export const getPublicContacts = async () => {
  let response = {};
  try {
    const r = await axios.get("http://localhost:3000/api/Contact/Public");
    response = r.data;
  } catch (error) {
    response.exceptions = error.response.data.exceptions;
  }

  return response;
};
