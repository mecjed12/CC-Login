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
];

export default class Fileinput extends React.Component {
    constructor(props) {
        super(props);
        this.state = { 
            name1: null,
            name2: null,
            title: null,
            svNumber: null,
            date: null,
            Gender: null,
            busy: null,
            busy_by: null,
            picture: null,
            function: null,
            active: null,
            deletedInactive: null,
            newsletterFlag: null,
        }
    }

    handleChange = (key, value) => {
        //checkt die Spalten ab ob nicht die gleichen genommen wurde
        const selectedValues = Object.values(this.state)
        var isDuplicate = false;
        selectedValues.forEach(selectedValue => {
            if (selectedValue === value.value) {
                alert("Spalte bereits ausgewählt!")
                isDuplicate = true;
            }
        })

        if (!isDuplicate) {
            console.log(value)
            this.setState({
                [key]: value.value
            })
        }
    }

    onUpload = () => {
        // check for required fields
        if (!this.state.name2 || !this.state.active || !this.state.deletedInactive || !this.state.newsletterFlag ) {
            alert("Bitte Feld auführen")
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
            active: this.state.active,
            deletedInactive: this.state.deletedInactive,
            newsletterFlag: this.state.newsletterFlag,
        }
      

        this.props.upload(stateToSend)
    }

    render() {
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        <tr>
                            <td>Vorname</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.name1)}
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
                            <td>Aktiv *</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.active)}
                                onChange={(newValue) => this.handleChange('active', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Löschen-Inaktiv *</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.deletedInactive)}
                                onChange={(newValue) => this.handleChange('deletedInactive', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Newsletter-flagge *</td>
                            <td> <Select
                                value={options.find(option => option.value === this.state.newsletterFlag)}
                                onChange={(newValue) => this.handleChange('newsletterFlag', newValue)}
                                options={options}
                            /></td>
                        </tr>
                       
                    </tbody>
                </table>
                <div type="button" className="button-click" onClick={() => this.onUpload()}>Upload</div>
            </div>
        )
    }
}