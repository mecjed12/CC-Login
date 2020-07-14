import React from 'react';
import './Fileinput.css';
import Select from 'react-select';

const options = [
    { value: null, label: 'Spalte auswählen ...' },
    { value: '0', label: 'Spalte 1' },
    { value: '1', label: 'Spalte 2' },
    { value: '2', label: 'Spalte 3' },
    { value: '3', label: 'Spalte 4' },
    { value: '4', label: 'Spalte 5' },
    { value: '5', label: 'Spalte 6' },
    { value: '6', label: 'Spalte 7' },
    { value: '7', label: 'Spalte 8' },
    { value: '8', label: 'Spalte 9' },
    { value: '9', label: 'Spalte 10' },
    { value: '10', label: 'Spalte 11' },
    { value: '11', label: 'Spalte 12' },
    { value: '12', label: 'Spalte 13' },
    { value: '13', label: 'Spalte 14' },
    { value: '14', label: 'Spalte 15' },
    { value: '15', label: 'Spalte 16' },

];

export default class Fileinput extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            properties: props.personFields
        }
        // this.state = { 
        //     name1: null,
        //     name2: null,
        //     title: null,
        //     svNumber: null,
        //     date: null,
        //     Gender: null,
        //     busy: null,
        //     busy_by: null,
        //     picture: null,
        //     function: null,
        //     email: null,
        //     phoneNumber: null,
        //     street: null,
        //     place: null,
        //     country: null,
        //     zipCode: null
        // }
    }

    handleChange = (key, value) => {
        //checkt die Spalten ab ob nicht die gleichen genommen wurde
        const selectedValues = Object.values(this.state.properties)
        var isDuplicate = false;
        selectedValues.forEach(selectedValue => {
            if (value.value !== null && selectedValue.columnValue === value.value) {
                alert("Spalte bereits ausgewählt!")
                isDuplicate = true;
            }
        })

        if (!isDuplicate) {
            const currentState = this.state.properties;
            const fieldToUpdate = currentState.find(field => field.propName === key)
            fieldToUpdate.columnValue = value.value

            this.setState({
                properties: currentState
            })
        }


        // console.log(value)
        // this.setState(prev => {
        //     prev.properties.map(x => (x.propName === key ? Object.assign(x, { columnValue: value.value }) : x))
        //     var isDuplicate = false;
        //     if(value.value !== null && options === value.newValue) {
        //         alert("Spalte bereits ausgewählt!")
        //         isDuplicate = true;

        //     }
        //     }
        // )
        // }
    }

    onUpload = () => {
        // check for required fields
        if (!this.state.name2) {
            alert("Bitte Feld ausfüllen")
            return
        }
        // ... all fields are filled
        const stateToSend = {
            name1: this.state.name1,
            name2: this.state.name2,
            title: this.state.title,
            svNumber: this.state.svNumber,
            date: this.state.date,
            Gender: this.state.Gender,
            busy: this.state.busy,
            busy_by: this.state.busy_by,
            picture: this.state.picture,
            function: this.state.function,
            email: this.state.email,
            phoneNumber: this.state.phoneNumber,
            street: this.state.street,
            place: this.state.place,
            country: this.state.country,
            zipCode: this.state.zipCode
        }
        this.props.upload(stateToSend)
    }
    render() {
        console.log(this.state)
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        {this.state.properties.map((newState) => {
                            var value = options.find(option => option.value === newState.columnValue)

                            const displayName = // check if newState.required === true ...

                            return (
                                <tr>
                                    <td>{newState.displayName}</td>
                                    <td> <Select
                                        value={value}
                                        onChange={(newValue) => this.handleChange(newState.propName, newValue)}
                                        options={options}
                                    /></td>
                                </tr>
                            )
                        }
                        )}

                        {/*
                        <tr>
                            <td>Vorname</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.name1)} // this.state[person.propName]
                                onChange={(newValue) => this.handleChange('name1', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Nachname *</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.name2)}
                                onChange={(newValue) => this.handleChange('name2', newValue)}
                                options={options} 
                            /></td>
                        </tr>
                        <tr>
                            <td>Titel</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.title)}
                                onChange={(newValue) => this.handleChange('title', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>SV-Nummer</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.svNumber)}
                                onChange={(newValue) => this.handleChange('svNumber', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Geburtsdatum</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.date)}
                                onChange={(newValue) => this.handleChange('date', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Geschlecht</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.Gender)}
                                onChange={(newValue) => this.handleChange('Gender', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Beschäftigt</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.busy)}
                                onChange={(newValue) => this.handleChange('busy', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Bäschftigtbei</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.busy_by)}
                                onChange={(newValue) => this.handleChange('busy_by', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Foto</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.picture)}
                                onChange={(newValue) => this.handleChange('picture', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Funktion</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.function)}
                                onChange={(newValue) => this.handleChange('function', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>E-Mail</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.email)}
                                onChange={(newValue) => this.handleChange('email', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Telefonnummer</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.phoneNumber)}
                                onChange={(newValue) => this.handleChange('phoneNumber', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Straße</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.street)}
                                onChange={(newValue) => this.handleChange('street', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Ort</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.place)}
                                onChange={(newValue) => this.handleChange('place', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>ZipCode</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.zipCode)}
                                onChange={(newValue) => this.handleChange('zipCode', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Bundesland</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.country)}
                                onChange={(newValue) => this.handleChange('country', newValue)}
                                options={options}
                            /></td>
                        </tr>
                       */}

                    </tbody>
                </table>
                <div type="button" className="button-click" onClick={() => this.onUpload()}>Upload</div>
            </div>
        )
    }
}