import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import {
  deletePrivateContact,
  postPrivateContact,
  putPrivateContact,
} from "../../services/contact";
import styles from "./ContactForm.module.css";

const ContactForm = (props) => {
  const { token } = useSelector((state) => state.auth);
  const navigate = useNavigate();
  const [isFormValid, setIsFormValid] = useState(null);

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [birthday, setBirthday] = useState("");
  const [category, setCategory] = useState({});
  const [subcategory, setSubcategory] = useState("");
  const [isPublic, setIsPublic] = useState(false);

  const onFirstNameChangeHandler = (event) => {
    const value = event.target.value;
    setFirstName(value);
  };
  const onLastNameChangeHandler = (event) => {
    const value = event.target.value;
    setLastName(value);
  };
  const onEmailChangeHandler = (event) => {
    const value = event.target.value;
    setEmail(value);
  };
  const onPhoneChangeHandler = (event) => {
    const value = event.target.value;
    setPhone(value);
  };
  const onBirthdayChangeHandler = (event) => {
    const value = event.target.value;
    setBirthday(value);
  };
  const onCategoryChangeHandler = (event) => {
    const value = event.target.value;
    const currentCategory = props.categories.find((c) => c.id == value);
    setCategory(currentCategory);
  };
  const onSubcategoryChangeHandler = (event) => {
    const value = event.target.value;

    let subcategoryName = "";
    if (isNaN(value) || value === "") {
      subcategoryName = value;
    } else {
      subcategoryName = category.applicableSubcategories.find(
        (as) => as.id == value
      ).name;
    }
    console.log(value);

    setSubcategory(subcategoryName);
  };
  const onIsPublicChangeHandler = (event) => {
    const value = event.target.checked;
    setIsPublic(value);
  };

  useEffect(() => {
    if (props.mode === "CREATE") {
      setCategory(props.categories[0]);
      setSubcategory(props.categories[0].applicableSubcategories[0].name);
    }

    if (props.mode !== "EDIT") return;
    setFirstName(props.contact.firstName);
    setLastName(props.contact.lastName);
    setEmail(props.contact.email);
    setPhone(props.contact.phone);
    const date = new Date(props.contact.birthday);
    const timezoneOffset = date.getTimezoneOffset() * 60000;
    var dateWithOffset = new Date(date.getTime() - timezoneOffset);
    setBirthday(dateWithOffset.toISOString().slice(0, 10));
    const currentCategory = props.categories.find(
      (c) => c.id == props.contact.category.id
    );
    setCategory(currentCategory);
    setSubcategory(props.contact.subcategory);
    setIsPublic(props.contact.isPublic);
  }, [props.categories, props.mode, props.contact]);

  let areCustomSubcateroriesAllowed = true;
  if (
    category.applicableSubcategories &&
    category.applicableSubcategories.length > 0
  ) {
    areCustomSubcateroriesAllowed = false;
  }

  const onSubmitHandler = async (event) => {
    event.preventDefault();

    const formData = {
      firstName,
      lastName,
      email,
      phone,
      birthday,
      categoryId: category.id,
      subcategory,
      isPublic,
    };
    console.log(formData);

    let response = null;
    if (props.mode === "EDIT") {
      response = await putPrivateContact(props.contact.id, formData, token);
    } else if (props.mode === "CREATE") {
      response = await postPrivateContact(formData, token);
    }
    if (!response.isSuccess) return setIsFormValid(false);

    navigate("/private-contacts");
  };

  let currentSubcategory = null;
  if (!areCustomSubcateroriesAllowed) {
    currentSubcategory = category.applicableSubcategories.find(
      (as) => as.name === subcategory
    );
  }

  const deleteContactHandler = async (event) => {
    await deletePrivateContact(props.contact.id, token);
    navigate("/private-contacts");
  };

  return (
    <form className={styles["contact-form"]} onSubmit={onSubmitHandler}>
      {isFormValid && <p>Invalid data!</p>}
      <div className={styles["contact-form--input-group"]}>
        <label htmlFor="first-name">First Name</label>
        <input
          id="first-name"
          type="text"
          required
          value={firstName}
          onChange={onFirstNameChangeHandler}
        />
      </div>
      <div className={styles["contact-form--input-group"]}>
        <label htmlFor="last-name">Last Name</label>
        <input
          id="last-name"
          type="text"
          required
          value={lastName}
          onChange={onLastNameChangeHandler}
        />
      </div>
      <div className={styles["contact-form--input-group"]}>
        <label htmlFor="email">Email</label>
        <input
          id="email"
          type="email"
          required
          value={email}
          onChange={onEmailChangeHandler}
        />
      </div>
      <div className={styles["contact-form--input-group"]}>
        <label htmlFor="phone">Phone</label>
        <input
          id="phone"
          type="tel"
          required
          value={phone}
          onChange={onPhoneChangeHandler}
        />
      </div>
      <div className={styles["contact-form--input-group"]}>
        <label htmlFor="birthday">Birthday</label>
        <input
          id="birthday"
          type="date"
          required
          defaultValue={birthday}
          onChange={onBirthdayChangeHandler}
        />
      </div>
      <div className={styles["contact-form--input-group"]}>
        <label htmlFor="category">Category</label>
        <select
          id="category"
          value={category.id}
          onChange={onCategoryChangeHandler}
        >
          {props.categories.map((c) => (
            <option key={c.id} value={c.id}>
              {c.name}
            </option>
          ))}
        </select>
      </div>
      <div className={styles["contact-form--input-group"]}>
        <label htmlFor="subcategory">Subcategory</label>
        {areCustomSubcateroriesAllowed === true && (
          <input
            id="subcategory"
            type="text"
            required
            value={subcategory}
            onChange={onSubcategoryChangeHandler}
          />
        )}
        {areCustomSubcateroriesAllowed === false && (
          <select
            id="subcategory"
            onChange={onSubcategoryChangeHandler}
            defaultValue={currentSubcategory ? currentSubcategory.id : null}
          >
            {category.applicableSubcategories.map((as) => (
              <option key={as.id} value={as.id}>
                {as.name}
              </option>
            ))}
          </select>
        )}
      </div>

      <div className={styles["contact-form--checkbox"]}>
        <input
          id="is-public"
          type="checkbox"
          checked={isPublic}
          onChange={onIsPublicChangeHandler}
        />
        <label htmlFor="is-public">Share with public</label>
      </div>

      <div className={styles["contact-form--actions"]}>
        {props.mode === "EDIT" && (
          <>
            <button
              type="button"
              className={styles["contact-form--delete-button"]}
              onClick={deleteContactHandler}
            >
              Delete
            </button>
          </>
        )}
        <button className={styles["contact-form--submit-button"]}>
          Submit
        </button>
      </div>
    </form>
  );
};
export default ContactForm;
