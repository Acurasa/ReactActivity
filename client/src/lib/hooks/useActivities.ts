import { useQuery } from "@tanstack/react-query";
import agent from "../agents/apiagent";

export const useActivities = () => {
    const { data: activities, isPending } = useQuery(
        {
          queryKey: ['activities'],
          queryFn: async () => {
            const response = await agent.get<Activity[]> ("/activities");
            return response.data;
          }
        }
      )

      return {
        activities,
        isPending
      }
}