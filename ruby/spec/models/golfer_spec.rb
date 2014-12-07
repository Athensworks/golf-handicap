require 'spec_helper'

describe Golfer do

  let(:joe) { Golfer.new("Joe") }

  it "should require a golfer's name" do
    expect(Golfer.new(nil)).to raise_error
  end

  it "should create a new golfer" do
    expect(joe).to be_kind_of(Golfer)
    expect(joe.name).to eq("Joe")
  end

  it "should allow you to append a score" do
    score = Score.new(score: 72, rating: 71, slope: 120)
    expect(joe.add_score(score)).to include(score)
    expect(joe.scores).to include(score)
  end

  it "should allow you to append scores" do
    scores = 5.times.collect { Score.new(score: 72, rating: 71, slope: 120) }
    expect(joe.add_scores(scores).count).to eq(5)
  end

  it "should calculate simple handicap" do
    score = Score.new(score: 84, rating: 70, slope: 113)
    joe.add_score(score)
    expect {joe.handicap}.to raise_error(RuntimeError, 'Not enough scores')
  end

  it "should calculate handicap" do
    file = open("spec/support/scores.json")
    json = JSON.parse(file.read)

    joe.import_scores(json)
    expect(joe.handicap).to eq(15.1)
  end

end
