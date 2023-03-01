import { useEffect, useState } from "react";

const useService = (service) => {
  const [data, setData] = useState(null);
  const [isPending, setIsPending] = useState(false);

  // useEffect(() => {
  //   const fetchData = async () => {
  //     setIsPending(true);

  //     const response = await service();
  //     setData(response);

  //     setIsPending(false);
  //   };
  //   fetchData();
  // }, [service]);

  const request = async (body) => {
    setIsPending(true);
    const response = await service(body);
    setIsPending(false);
    return response;
  };

  return { request, isPending };
};

export default useService;
