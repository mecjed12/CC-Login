import React from 'react';
import '../Dropdown/Dropdown.css';
import Select from 'react-select';

const options = [
    { value: 'Person', label: 'Person' },
    { value: 'Course', label: 'Course' },
];

export default class Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectionOption: null,
        }
    }
    handelchange = selectionOption => {
        this.setState(
            { selectionOption },
            () => console.log('Option selected:', this.state.selectionOption)
        );
    };
    render() {
        const { selectionOption } = this.state;
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        <tr>
                            <td><Select
                                value={options.find(option => option.value === this.state.name1)}
                                onChange={(newValue) => this.handleChange('name1', newValue)}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
            </div>


        )

    }
}