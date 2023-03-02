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

export const getPrivateContacts = async (token) => {
  let response = {};
  try {
    const r = await axios.get("http://localhost:3000/api/Contact", {
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

export const getPrivateContact = async (id, token) => {
  let response = {};
  try {
    const r = await axios.get("http://localhost:3000/api/Contact/" + id, {
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

export const putPrivateContact = async (id, data, token) => {
  let response = { isSuccess: false, data: null };
  try {
    const r = await axios.put("http://localhost:3000/api/Contact/" + id, data, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    response.data = r.data;
    response.isSuccess = true;
  } catch (error) {
    response.isSuccess = false;
  }

  return response;
};

export const deletePrivateContact = async (id, token) => {
  let response = { isSuccess: false, data: null };
  try {
    const r = await axios.delete("http://localhost:3000/api/Contact/" + id, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    response.data = r.data;
    response.isSuccess = true;
  } catch (error) {
    response.isSuccess = false;
  }

  return response;
};

export const postPrivateContact = async (data, token) => {
  let response = { isSuccess: false, data: null };
  console.log(data);
  try {
    const r = await axios.post("http://localhost:3000/api/Contact", data, {
      headers: {
        Authorization: "Bearer " + token,
      },
    });
    response.data = r.data;
    response.isSuccess = true;
  } catch (error) {
    response.isSuccess = false;
  }

  return response;
};
