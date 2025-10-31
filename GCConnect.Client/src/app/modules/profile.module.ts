import { NgModule } from "@angular/core";
import { ProfileDetailsComponent } from "../components/profile-details/profile-details.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

// profile.module.ts
@NgModule({ 
    declarations: [ProfileDetailsComponent],
    imports: [CommonModule, RouterModule.forChild([
        { path: '', component: ProfileDetailsComponent }
    ])]
})
export class ProfileModule { }