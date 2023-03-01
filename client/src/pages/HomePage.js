import { useLoaderData } from "react-router-dom";
import Contacts from "../components/contacts/contacts";
import { getPublicContacts } from "../services/contact";

const HomePage = (props) => {
  const { contacts } = useLoaderData();
  return (
    <>
      <Contacts contacts={contacts} />
    </>
  );
};
export default HomePage;

export const homePageLoader = async () => {
  const contacts = await getPublicContacts();
  return { contacts };
};
