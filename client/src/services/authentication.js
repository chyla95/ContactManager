import axios from "axios";

export const signIn = async (data) => {
  const { email, password } = data;

  let response = {};
  try {
    const r = await axios.post(
      "http://localhost:3000/api/Authorization/SignIn",
      {
        email,
        password,
      }
    );
    response = r.data;
  } catch (error) {
    response.exceptions = error.response.data.exceptions;
  }

  return response;
};

export const signUp = async (data) => {
  const { email, password } = data;

  let response = {};
  try {
    const r = await axios.post(
      "http://localhost:3000/api/Authorization/SignUp",
      {
        email,
        password,
      }
    );
    response = r.data;
  } catch (error) {
    response.exceptions = error.response.data.exceptions;
  }

  return response;
};
