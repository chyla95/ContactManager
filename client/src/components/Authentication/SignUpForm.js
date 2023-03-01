import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router";
import styles from "./SignUpForm.module.css";
import { authActions } from "../../store/auth-slice";
import useService from "../../hooks/use-service";
import { signUp } from "../../services/authentication";

const SignUpForm = (props) => {
  const { token } = useSelector((state) => state.auth);
  const dispatch = useDispatch();
  const { request, isPending } = useService(signUp);
  const [formErrors, setFormErrors] = useState([]);

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const onEmailChangeHandler = (event) => {
    const value = event.target.value;
    setEmail(value);
  };

  const onPasswordChangeHandler = (event) => {
    const value = event.target.value;
    setPassword(value);
  };

  const onSubmitHandler = async (event) => {
    event.preventDefault();
    const response = await request({
      email,
      password,
    });
    if (response.exceptions) return setFormErrors(response.exceptions);
    if (!response.jwt)
      return setFormErrors([
        {
          exception: "Invalid input!",
        },
      ]);

    dispatch(authActions.authenticate(response.jwt));
    localStorage.setItem("token", response.jwt);

    navigate(0);
    if (props.onSubmit) props.onSubmit();
  };

  const formErrorHolder = (
    <div className={styles["form--error-holder"]}>
      <ul>
        {formErrors.map((fe) => (
          <p key={fe.exception}>{fe.exception}</p>
        ))}
      </ul>
    </div>
  );

  return (
    <form className={styles["form"]} onSubmit={onSubmitHandler}>
      <h2>Sign Up</h2>
      <h4>Account creation</h4>
      {formErrors && formErrorHolder}

      <div>
        <label htmlFor="email">Email</label>
        <input
          type="text"
          id="email"
          required
          onChange={onEmailChangeHandler}
          value={email}
        />
      </div>
      <div>
        <label htmlFor="password">Password</label>
        <input
          type="password"
          id="password"
          required
          onChange={onPasswordChangeHandler}
          value={password}
        />
      </div>
      <div className={styles["button-group"]}>
        <button
          type="button"
          onClick={props.changeAction.bind(this, "SignIn")}
          className={styles["change-action-button"]}
        >
          <b>
            <u>Sign In</u>
          </b>{" "}
          instead
        </button>
        <div className={`${styles["actions"]}`}>
          <button autoFocus>Sign Up</button>
        </div>
      </div>
    </form>
  );
};

export default SignUpForm;
