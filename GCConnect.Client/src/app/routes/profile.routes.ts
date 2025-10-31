import { Routes } from "@angular/router";
import { ProfileDetailsComponent } from "../components/profile-details/profile-details.component";
import { ROUTES } from "../common/constants/routes.constants";

const ProfileRoutes: Routes = [
    {
        path: ROUTES.root,
        component: ProfileDetailsComponent,
    }
];

export { ProfileRoutes };