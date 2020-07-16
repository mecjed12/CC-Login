import React from 'react';
import Select from 'react-select';


const options = [
    { value: true, label: 'KURSE' },
    { value: false, label: 'PERSONEN' },
];

export default class Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedOption: null
        }
    }
    
    handelchange = selectedOption => {
        this.setState(
            {selectedOption},
        );
        this.props.toggleClass(selectedOption.value)
    };
   
    render() {
        return (
            <div>
                <table className="dropdown">
                    <tbody>
                        <tr>
                            <td><Select
                                value={this.state.selectedOption}
                                onChange={ this.handelchange}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}