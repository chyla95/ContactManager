import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  user: null,
};

export const userSlice = createSlice({
  name: "user",
  initialState: initialState,
  reducers: {
    update(state, action) {
      const user = action.payload;
      state.user = user;
    },
  },
});

export const userActions = userSlice.actions;
