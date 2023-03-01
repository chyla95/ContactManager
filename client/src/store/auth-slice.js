import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  token: localStorage.getItem("token") || null,
};

export const authSlice = createSlice({
  name: "auth",
  initialState: initialState,
  reducers: {
    authenticate(state, action) {
      const { jwt: token } = action.payload;
      state.token = token;
    },
    deauthenticate(state, action) {
      state.token = null;
    },
  },
});

export const authActions = authSlice.actions;

export const deauthenticateActionCreator = () => {
  return async (dispatch) => {
    localStorage.removeItem("token");
    dispatch(authActions.deauthenticate());
  };
};
