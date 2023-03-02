import { useNavigate } from "react-router-dom";
import styles from "./Contact.module.css";

const Contact = (props) => {
  const navigate = useNavigate();

  const onClickHandler = () => {
    if (props.isClickable) navigate(`/private-contacts/${props.contact.id}`);
  };

  return (
    <div
      className={`${styles["contact"]} ${
        props.isClickable && styles["interactive-contact"]
      } shielded`}
      onClick={onClickHandler}
    >
      <h2 className={styles["full-name"]}>
        {props.contact.firstName} {props.contact.lastName}
      </h2>
      <h3>Contact:</h3>
      <p>
        <b>Phone: </b>
        {props.contact.phone}
      </p>
      <p>
        <b>Email: </b>
        {props.contact.email}
      </p>
    </div>
  );
};

export default Contact;
