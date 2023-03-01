import styles from "./contact.module.css";

const Contact = (props) => {
  return (
    <div className={`${styles["contact"]} shielded`}>
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
