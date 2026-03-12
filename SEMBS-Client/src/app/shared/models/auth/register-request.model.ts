export interface RegisterRequest {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    rolename: 'User' | 'Organizer';
}
